from cool_itv import get_channels
from google.appengine.ext import db, deferred
import logging


logger = logging.getLogger('silviaplayer.models')


class Channel(db.Model):
    name = db.StringProperty(required=True)
    sop_urls = db.StringListProperty()


def search_channels(text):
    q = Channel.all().order('name').fetch(100)
    return q


def run_import():
    logger.info('refresh channels started.')

    existings = dict((i.name, i) for i in Channel.all().fetch(100))

    modified = []
    for name, urls in get_channels():
        logger.info('fetched channel: ' + name)
        if name in existings:
            channel = existings[name]
            if set(channel.sop_urls) != set(urls):
                channel.sop_urls = urls
                modified.append(channel)
        else:
            modified.append(Channel(name=name, sop_urls=urls))

    if modified:
        logger.info('%s channels has been updated.', len(modified))
        db.put(modified)
    else:
        logger.info('no channel has been updated.')



def start_refresh_channels():
    deferred.defer(run_import)
