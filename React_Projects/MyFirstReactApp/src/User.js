import React from 'react';
import pic from './pics/bluetank.jpg';
import './style/App.css'

class User extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            name : '',
            pass : '',
            degree : ''
        }

    }
    render(){
        return(
            <div className="userDiv">
                <img src={pic}  className='w3-circle' alt='user pic' style={{float: 'right', width:50 , height:50}}/>
                <h5 className="username">{this.props.degree} / {this.props.name}</h5>
            </div>

        );
    }

}
export default User;