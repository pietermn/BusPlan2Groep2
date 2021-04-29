import React, {useState} from 'react';
import '../../Style/plannerStyles.css';
import Navbar from './Navbar';
import Table from './Table';

const Planner = () => {

    const [selectedType, setSelectedType] = useState('')

    const handleNavbar = (type) => {
        setSelectedType(type);
    }

    return (
        <div className="planner_full_page">
            <Navbar func={handleNavbar}/>
            <Table />
        </div>
    )
}

export default Planner;