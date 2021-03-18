import React from 'react';
import whitearrow from '../Images/Icons/whitearrow.png';
import {useHistory} from 'react-router-dom';


const Button = ({text, redirect}) => {
    const history = useHistory();
    return (
        <div onClick={() => history.push(redirect)} className="button-component">
            <p>{text}</p>
            <img src={whitearrow} alt="arrow"/>
        </div>
    )
}

export default Button;