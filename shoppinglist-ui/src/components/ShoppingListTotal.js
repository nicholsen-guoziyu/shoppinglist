import React, {Component} from "react";

class ShoppingListTotal extends Component
{
    constructor(props)
    {
        super(props);
    }

    render()
    {
        let sum = 0;
        if(props.items.length >= 1)
        {
            sum = props.items.reduce(function (total, currentValue) {
                return total + currentValue.itemPrice;
            })
        }
        return(
            <div class="ShoppingListTotal">
                <label class="item">Total </label>
                <label class="item">${sumValue} </label>
            </div>
        )
    }
}