import React from "react";
import App from './App.js';

class Login extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            username : '' ,
            password : '',
            degree : '' 
        }
    }

    render(){
        return(
            <App username = 'عبدالله محمد عبدالله' 
                 degree = 'جندي مقاتل'></App>
        );
    }


}
export default Login;