import React from "react";
import './style/App.css';
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import { AiOutlineArrowLeft } from "react-icons/ai";
import MyHeader from "./MyHeader";
import CardsList from "./CardsList" ;

class App extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            username : '' ,
            degree : '' 
        }
    }

    render(){
        return (

            <div className='myApp' >
                <MyHeader username={this.props.username} degree={this.props.degree}></MyHeader>
                <div className='mybody'>
                    <Tabs >
                        <div className="Tabs">
                        <AiOutlineArrowLeft className="back" fontSize={30}></AiOutlineArrowLeft>
                            <TabList>
                                <Tab>الرئيسية</Tab>
                                <Tab>المقترحين</Tab>
                                <Tab>الجنود</Tab>
                            </TabList>
                        </div>
                        <div className="tabspanel">
                            <TabPanel>
                                <CardsList></CardsList>
                            </TabPanel>
                            <TabPanel>
                                <p>Tab 2 works!</p>
                            </TabPanel>
                            <TabPanel>
                                <p>Tab 3 works!</p>
                            </TabPanel>
                        </div>
                    </Tabs>
                </div>
            </div>
        );
    }    
}
  
export default App;