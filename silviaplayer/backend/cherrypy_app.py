# -*- coding: utf-8 -*-
from silviaplayer.backend import model
from silviaplayer.backend.jinja_template import render_template

import cherrypy
from cherrypy import tools
import wsgiref.handlers


class WebUI(object):
    @cherrypy.expose
    def index(self):
        return render_template('index.html')

    @cherrypy.expose
    def cooltv_list(self):
        pass

    @cherrypy.expose
    def cooltv_refresh(self):
        model.start_refresh_channels()
        return "refresh"

    @cherrypy.expose
    def cooltv_status(self):
        return "status"



class ChannelResource(object):
    exposed = True

    @tools.json_out()
    def GET(self):
        results = model.search_channels(None)
        return {
            'items':[{
                    'URI': 'channel/%s/' % i.name,
                    'name': i.name,
                    'sop_urls': i.sop_urls,
                    } for i in results],
            'total': len(results),
            }


class RestApi(object):
    channel = ChannelResource()


def main():
    cherrypy.tree.mount(RestApi(), '/api', {
            '/': {
                'request.dispatch': cherrypy.dispatch.MethodDispatcher(),
                },
            })
    cherrypy.tree.mount(WebUI(), '', {
            '/': {
                'log.screen': False,
                },
            })
    wsgiref.handlers.CGIHandler().run(cherrypy.tree)
