
log_info = (text) ->
  console.info text if window.console


###
# Model for Channel
#
###
class Channel extends Backbone.Model
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


###
# the collection of Channel items
#
###
class ChannelList extends Backbone.Collection
  model: Channel

  url: '/api/channel/'

  parse: (response) ->
    response.items


#----------------------------------

###
# view for a playing channel, embedds the actual activex sop player
#
###
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


###
# view for a channel in available lists
#
###
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


###
# display the available and playing channels
#
###
class ListView extends Backbone.View
  el: $('#channel_list')

  events:
    "keydown #search": "liveFilter"

  initialize: ->
    _.bindAll @

    @collection = new ChannelList
    #    @collection.bind 'add', @appendItem
    @collection.bind 'change', @channelChanged
    @collection.fetch success: @filterChannels

  appendItem: (item) ->
    #    log_info "appendItem: #{item}"
    item_view = new ChannelView model: item
    @$('#channels').append item_view.render().el

  channelChanged: (ch) ->
    if ch.get 'play'
      item_view = new PlayingChannelView model: ch
      @$('#playing_channels').append item_view.render().el

  timeout: null
  liveFilter: ->
    clearTimeout(@timeout) if @timeout
    timeout = setTimeout(@filterChannels, 50)

  filterChannels: ->
    @$('#channels').children().remove()
    @$('#searchResult').text("")

    text = @$('#search').val()
    log_info "filter text: #{text}"

    l = @collection.models
    if text != ""
      filter = (x) -> x.get('play') or x.get('name').indexOf(text) != -1
      l = _.filter(l, filter)
      [l_size, all_size] = [_.size(l), _.size(@collection.models)]
      @$('#searchResult').text("#{l_size} matched from #{all_size}")
    _.each l, @appendItem



# the main
window.list_view = new ListView
