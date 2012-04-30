
log_info = (text) ->
  console.info text if window.console



class Item extends Backbone.Model
  defaults:
    play: null

  toString: ->
    "Item: #{@get 'name'}"

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


class ItemView extends Backbone.View
  tagName: 'li'

  template: _.template $('#item-template').html()

  events:
    "click .play": "playStation"
    "click .stop": "stop"

  initialize: ->
    _.bindAll @
    @model.bind 'change', @render

  render: ->
    $(@el).html @template @model.toJSON()
    @

  playStation: (e) ->
    e.preventDefault()
    @model.start e.target

  stop: ->
    @model.stop()


class ListView extends Backbone.View
  el: $('#channels')

  initialize: ->
    _.bindAll @

    @collection = new List
    @collection.bind 'add', @appendItem
    @collection.bind 'change', @arrangeItems

    @collection.fetch add: true

  appendItem: (item) ->
    log_info "append item"
    item_view = new ItemView model: item
    $(@el).append item_view.render().el

  arrangeItems:  ->
    log_info "playable go first"


window.list_view = new ListView
