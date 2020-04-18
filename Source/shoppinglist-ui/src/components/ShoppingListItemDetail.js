import React, { Component } from 'react';
class ShoppingListItemDetail extends Component
{
    constructor(props)
    {
        super(props);

    }

    render()
    {
        return
        (
            <div class="ShoppingListItemDetail collapsible-item hide">
                <label class="item" for="File1">Upload File </label><input class="item" type="file" id="File1" name="File1" />
                <label class="item" for="Store1">Store </label><input class="item" type="text" id="Store1" name="Store1" />
                <label class="item" for="Name1">Name </label><input class="item" type="text" id="Name1" name="Name1" />
                <label class="item" for="Brand1">Brand </label><input class="item" type="text" id="Brand1" name="Brand1" />
                <label class="item" for="Quantity1">Quantity </label><input class="item" type="text" id="Quantity1" name="Quantity1" />
                <label class="item" for="Price1">Price </label><input class="item" type="text" id="Price1" name="Price1" />
                <label class="item" for="Priority1">Priority </label><select class="item" id="Priority1" name="Priority1">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                </select>
                <label class="item" for="Remark1">Remark </label><textarea class="item" rows="10" cols="30" name="Remark1"></textarea>
                <img class="item-image"  />
                <div class="ShoppingListItemAction">
                    <button type="submit">Save</button>
                    <button type="submit">Delete</button>
                </div>
            </div>
        )
    }
}