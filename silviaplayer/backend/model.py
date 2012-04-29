from google.appengine.ext import db


class Channel(db.Model):
    name = db.StringProperty(required=True)
    sop_urls = db.StringListProperty()


def search_channels(text):
    q = Channel.all().order('name').fetch(100)
    return q
