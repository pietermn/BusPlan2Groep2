import React from 'react';
import {useHistory} from 'react-router-dom';

const Scanning = () => {
    const history = useHistory();

    return (
        <div className="scanning" >
            <h1>Scan Bus</h1>
            <button onClick={() => history.push('manual')}>Manual</button>
        </div>
    )
}

export default Scanning;