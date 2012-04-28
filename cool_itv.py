#!/usr/bin/env python

import re, sys
import urllib2
from StringIO import StringIO
from itertools import groupby


def get_channels():
    url = 'http://www.cool-itv.net/'

    def get_pages():
        content = urllib2.urlopen(url).read()
        for l in StringIO(content):
            if re.match('stm_.*"ch/[^"]*.*', l):
                yield re.sub(r'stm_.*"(ch/[^"]*)".*', r'\1', l).strip()

    def get_sopurl(page_url):
        content = urllib2.urlopen(page_url).read()
        for l in StringIO(content):
            if re.search(r'sop://broker', l):
                return re.sub(r'.*value="([^"]*)".*', r'\1', l).strip()

    for p in get_pages():
        if 'protv' in p:
            sop_url = get_sopurl(url + p)
            if sop_url:
                ch_name = re.sub(r'ch/(.*)-s[0-9]*\.html', r'\1', p)
                yield ch_name, sop_url

def main():
    for ch, stations in groupby(get_channels(), key=lambda x: x[0]):
        print ch, list(s[1] for s in stations)


if __name__ == "__main__":
    main()
