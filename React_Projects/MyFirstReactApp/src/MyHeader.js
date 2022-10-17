import React from "react";
import User from'./User';
import logo from './pics/flag.png';
import './style/App.css';

function MyHeader (props) {
    return(
    <div className='myheader' >
     
        <img className="logo" src={logo} alt='logo' ></img>
     
        <h4 className="headtxt"> فرع الأفراد والتعبئة </h4>
         
        <User name={props.username} degree={props.degree}></User>
     
        
        {/* <TextField className='srchtxt' label="" variant="outlined" size='small' /> */}
        {/* <DeleteIcon sx={{ color: blue[500] }}/> */}
        {/* <a onClick={()=>window.location='./src/pages/App2.js'}>sdcfsdc</a> */}
    </div>
);
}

export default MyHeader;