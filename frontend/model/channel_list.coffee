
log_info = (text) ->
  console.info text if window.console



class Item extends Backbone.Model
  defaults:
    play: null

  toString: ->
    "Channel: #{@get 'name'} #{@get 'play'}"

  start: (station) =>
    @set play: station
    log_info "start: #{@get 'name'}  #{station}"

  stop: ->
    @set play: null
    log_info "stop: #{@get 'name'}"


class List extends Backbone.Collection
  model: Item

  url: '/api/channel/'

  parse: (response) ->
    response.items


#----------------------------------

class PlayingChannelView extends Backbone.View
  tagName: 'li'

  template: _.template $('#playing-channel-template').html()

  events:
    "click .stop": "stop"

  initialize: ->
    _.bindAll @

  render: ->
    $(@el).attr id: @model.name
    $(@el).addClass 'grid-4'
    $(@el).html @template @model.toJSON()
    @

  stop: ->
    @model.stop()
    $(@el).remove()


class ChannelView extends Backbone.View
  tagName: 'li'

  template: _.template $('#channel-template').html()

  events:
    "click .play": "playStation"

  initialize: ->
    _.bindAll @
    @model.bind 'change', @render

  render: ->
    $(@el).addClass 'grid-3'
    $(@el).html @template @model.toJSON()
    @

  playStation: (e) ->
    e.preventDefault()
    @model.start e.target



class ListView extends Backbone.View
  el2: $('#playing_channels')
  el: $('#channels')

  initialize: ->
    _.bindAll @

    @collection = new List
    @collection.bind 'add', @appendItem
    @collection.bind 'change', @channelChanged

    @collection.fetch add: true

  appendItem: (item) ->
    log_info "append item"
    item_view = new ChannelView model: item
    $(@el).append item_view.render().el

  channelChanged: (ch) ->
    if ch.get 'play'
      item_view = new PlayingChannelView model: ch
      $('#playing_channels').append item_view.render().el

    log_info "playable go first: " + ch


window.list_view = new ListView
