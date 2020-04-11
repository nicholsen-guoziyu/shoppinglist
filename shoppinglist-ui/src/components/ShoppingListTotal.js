import React, {Component} from "react";

class ShoppingListTotal extends Component
{
    render()
    {
        let sum = 0;
        if(this.props.items.length >= 1)
        {
            sum = this.props.items.reduce(function (total, currentValue) {
                return total + parseInt(currentValue.itemPrice, 10);
            }, 0)
        }
        return(
            <div className="ShoppingListTotal">
                <label className="item">Total </label>
                <label className="item">${sum.toString()} </label>
            </div>
        )
    }
}

export default ShoppingListTotal