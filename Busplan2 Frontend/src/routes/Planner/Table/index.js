import React from 'react';

const Table = ({ type, data }) => {
    return (
        <div className="planner-table">
            <div className="row indexRow">
                <span className="bus">Bus:</span>
                <span className="description">Uitleg:</span>
                <span className="doneby">{type} door:</span>
                <span className="date">{type} op:</span>
            </div>

            <div className="adhoc-container">
                {
                    data && data.map((adhoc) => {
                        return (
                            <div key={adhoc.adHocID} className="row">
                                <span className="bus">{adhoc.busID}</span>
                                <span className="description">{adhoc.description}</span>
                                {adhoc.accountID == 0 ? <span className="doneby"> - </span> : <span className="doneby">{adhoc.accountID}</span>}
                                {adhoc.timeDone == "0001-01-01T00:00:01" ? <span className="date">Nog niet klaar</span> : <span className="date">{adhoc.timeDone}</span>}
                            </div>
                        )
                    })
                }
            </div>
        </div>
    )
}

export default Table;