
class Item extends Backbone.Model
  toString: ->
    "Item: #{@get 'name'}"


class List extends Backbone.Collection
  model: Item

  url: '/api/channel/'

  parse: (response) ->
    response.items


#----------------------------------


class ItemView extends Backbone.View
  tagName: 'li'

  initialize: ->
    _.bindAll @

  render: ->
    $(@el).html "<span>#{@model.get 'name'}</span>"
    @


class ListView extends Backbone.View
  el: $('#channels')

  initialize: ->
    _.bindAll @

    @collection = new List
    @collection.bind 'add', @appendItem

    @render()

    @collection.fetch add: true

  render: ->
    $(@el).append '<ul></ul>'

  appendItem: (item) ->
    console.info "append item"
    item_view = new ItemView model: item
    $('ul').append item_view.render().el


window.list_view = new ListView
