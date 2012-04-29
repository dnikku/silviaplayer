# -*- coding: utf-8 -*-
from silviaplayer.backend import model
import cherrypy
from cherrypy import tools
import wsgiref.handlers


class WebUI(object):

    @cherrypy.expose
    def index(self):
        return "index page"

   @cherrypy.expose
    def cooltv_list(self):
        pass

    @cherrypy.expose
    def cooltv_refresh(self):
        pass

    @cherrypy.expose
    def cooltv_status(self):
        pass



class ChannelResource(object):
    exposed = True

    @tools.json_out()
    def GET(self):
        results = model.search_channels(None)
        return {
            'items':[{
                    'URI': 'channel/%s/' % str(i.id),
                    'id': str(i.id),
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
