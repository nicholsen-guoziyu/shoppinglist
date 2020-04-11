import React, { Component } from 'react';

class Calendar extends Component
{
    handleClickedDate(e){
        this.props.onDateClick(e.target.value);
    }

    render()
    {
        return(
            <div id="Calendar" className="calendar hide">
                <header>
                    <h4>April 2020</h4>
                </header>
                <ul className="weekdays">
                    <li>
                        <abbr title="S">Sunday</abbr>
                    </li>
                    <li>
                        <abbr title="M">Monday</abbr>
                    </li>
                    <li>
                        <abbr title="T">Tuesday</abbr>
                    </li>
                    <li>
                        <abbr title="W">Wednesday</abbr>
                    </li>
                    <li>
                        <abbr title="T">Thursday</abbr>
                    </li>
                    <li>
                        <abbr title="F">Friday</abbr>
                    </li>
                    <li>
                        <abbr title="S">Saturday</abbr>
                    </li>
                </ul>
                <ul className="day-grid">
                    <li className="month=prev">29</li>
                    <li className="month=prev">30</li>
                    <li className="month=prev">31</li>
                    <li>1</li>
                    <li>2</li>
                    <li>3</li>
                    <li>4</li>
                    <li>5</li>
                    <li>6</li>
                    <li>7</li>
                    <li>8</li>
                    <li>9</li>
                    <li>10</li>
                    <li>11</li>
                    <li>12</li>
                    <li>13</li>
                    <li>14</li>
                    <li>15</li>
                    <li>16</li>
                    <li>17</li>
                    <li>18</li>
                    <li>19</li>
                    <li>20</li>
                    <li>21</li>
                    <li>22</li>
                    <li>23</li>
                    <li>24</li>
                    <li>25</li>
                    <li>26</li>
                    <li>27</li>
                    <li>28</li>
                    <li>29</li>
                    <li>30</li>
                    <li className="month-next">1</li>
                    <li className="month-next">2</li>
                </ul>
            </div>
        )
    }
}

export default Calendar;