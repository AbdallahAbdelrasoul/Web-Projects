import React from 'react';
import 'w3-css/w3.css';
import './style/App.css'; 
import pic from './pics/bluetank.jpg';
import { useState } from 'react';
import { Add } from "@mui/icons-material";


const Card = (props) =>{

  const [isShown, setIsShown] = useState("hidden");

  const onMouseEnterHandler = () => {
      setIsShown("visible");    
      console.log(isShown);
  }
  
  const onMouseLeaveHandler = () => {
      setIsShown("hidden");    
      console.log(isShown);
  }

  return(
    <div className='w3-container'>      
      <div className='w3-card-4 myCard'
        onMouseEnter={onMouseEnterHandler}
        onMouseLeave={onMouseLeaveHandler}>
        <header className='w3-light-grey cardtop'>
          <h3 className='cardname'>{props.cardname}</h3>
          <button 
            className='addbtn'
            style={{visibility:isShown}}>
              <Add id="addIcon"></Add>
          </button>
        </header>

        <div className='cardDetails'>
          <div className='personDetails'>
            <p>{props.cardDegree}</p>
            <p>{props.cardUnit}</p>
            <p>{props.cardMilNo}</p>
            <p>{props.cardDateDm}</p>
          </div>
          <div className='picture'>
          <img src={pic} alt="Avatar" className='pic'/>
          </div>
        </div>
        
        <div className='history'>
          <p>الوحدة : 12/1/2015</p>
          <p>الوحدة : 12/1/2015</p>
          <p>الوحدة : 12/1/2015</p>
          <p>الوحدة : 12/1/2015</p>
        </div>
      </div>
    </div>
    
  );
}

export default Card;