import React from "react";
import './style/App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import TextField from '@mui/material/TextField';
import InputAdornment from '@mui/material/InputAdornment';
import { SearchOutlined } from "@mui/icons-material";

class Mysearch extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            // searchText : ''
        }
    }

    onChangeHandler = (event) => {
        // this.setState({searchText : event.target.value});
        this.props.onSearch(event.target.value);
    }

    // this.props.onSearch('123');
    // return this.state.searchText;
    searchHandler = () => {
        
    }
    
    render(){
        return(
            <div className="mysearchdiv">
                <TextField
                    id="mysearch"
                    placeholder="بحث..."
                    onChange = {this.onChangeHandler}
                    InputProps={{
                    startAdornment: (
                        <InputAdornment position="start" onClick={this.searchHandler}>
                            <SearchOutlined id="srchIcon"/>
                        </InputAdornment>
                    ),
                    }}
                variant="standard"
                />
            </div>
        );
    }
    
}

export default Mysearch;



 // const [isshown, setIsShown] = useState("disabled");

    // const onClickHandler = () => {
    //     if(isshown === "disabled")
    //         setIsShown("");
    //     else
    //         setIsShown("disabled");
        
    //     console.log(isshown);
    // }
