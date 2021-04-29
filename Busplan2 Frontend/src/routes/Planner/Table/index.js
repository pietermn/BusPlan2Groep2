import React from 'react';

const Table = ({ column_titles, data }) => {
    return (
        <div className="planner-table">
            <div className="bus">
                <ul>
                    <li>Bus</li>
                </ul>
            </div>
            <div className="status">
                <ul>
                    <li>Status</li>
                </ul>
            </div>
            <div className="doneby">
                <ul>
                    <li>Schoongemaakt door:</li>
                </ul>
            </div>
            <div className="date">
                <ul>
                    <li>Schoongemaakt op:</li>
                </ul>
            </div>
        </div>
    )
}

export default Table;