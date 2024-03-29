#!/usr/bin/env python

import re, sys
import urllib2
from StringIO import StringIO
from itertools import groupby

url = 'http://www.cool-itv.net/'


def get_channels():

    def get_pages():
        content = urllib2.urlopen(url).read()
        for l in StringIO(content):
            if re.match('stm_.*"ch/[^"]*.*', l):
                yield re.sub(r'stm_.*"(ch/[^"]*)".*', r'\1', l).strip()

    def get_sop_url(page_url):
        content = urllib2.urlopen(page_url).read()
        for l in StringIO(content):
            if re.search(r'sop://broker', l):
                return re.sub(r'.*value="([^"]*)".*', r'\1', l).strip()

    pairs = []
    for p in get_pages():
        sop_url = get_sop_url(url + p)
        if sop_url:
            ch_name = re.sub(r'ch/(.*?)(-s\d+)?\.html', r'\1', p)
            pairs.append((ch_name, sop_url))

    for ch, stations in groupby(pairs, key=lambda x: x[0]):
        yield ch, list(s[1] for s in stations)


if __name__ == "__main__":
    for ch, stations in get_channels():
        print ch, stations
