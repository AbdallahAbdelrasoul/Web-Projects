import React from "react";
import { Button } from 'react-bootstrap';


class MyBtn extends React.Component{
    constructor(props){
      super(props);
      this.state= {
        show : 0,
        innerHTML : "إظهار",
        backcolor : "orange",
      }
    }
  
    showList = () => {
      this.setState( {innerHTML : "إخفاء", show : 1, backcolor : "red"});
    }
  
    hideList = () => {
      this.setState( {innerHTML : "إظهار" , show : 0 , backcolor : "orange"} );
    }
  
    ClickHandler = () => {  
      if (this.state.show === 0  ){
        this.showList();
        console.log(this.state.backcolor);
      }
      else{
        this.hideList();
        console.log(this.state.backcolor);
      }
    }
  
    render(){
      return(
        <Button id = "myBtn" variant="primary" onClick={this.ClickHandler}
         style = {{backgroundColor : this.state.backcolor}}>
          {this.state.innerHTML}
          </Button>
      );
    }
  }

export default MyBtn;