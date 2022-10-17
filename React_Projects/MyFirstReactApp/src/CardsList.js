import React from "react";
import './style/App.css';
import Card from './Card';
import Mysearch from './Mysearch';
import CountUp from "react-countup";

const data =
            [
                {
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
                {
                    MIL_NO: "2019510403206",
                    PERSON_NAME: "مصطفى محمود عبدالحميد على",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019510403206.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "كاتب عسكري/رتب عالى - مجند /عريف",
                    SERV_NAME: "متوسطة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
                {
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
                {
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
                {
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
                {
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },{
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },{
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },{
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },{
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },{
                    MIL_NO: "2019506607820",
                    PERSON_NAME: "جلال ناصر محمد شلبى",
                    DEGREE_NAME: "جندى",
                    IMG_PERSON: "2019506607820.jpeg",
                    UNIT_NAME: "رئاسة اداره المدرعات",
                    ARMY_JOB_NAME: "سائق عربة / مجند / جندى",
                    SERV_NAME: "عادة",
                    DOF3A_TAGNEED_YEAR: 2019,
                    TMAM: null
                },
            ];

class CardsList extends React.Component {
    
    constructor(props){
        super(props);
        this.state = {
            // filtertxt : '',
            DataToShow : data,
        }
        
    }

    handleSearch(val){
        if (val === ""){
            this.setState ( 
            {
                DataToShow : data
            }
            );
        }
        else{
                // const {DataToShow} = this.state;
                const filteredData = data.filter(
                    e => (e.MIL_NO).includes(val) ||
                    (e.PERSON_NAME).includes(val)

                );
                this.setState(
                    {DataToShow : filteredData}
                );
        } 
    }

    render(){
        // const {DataToShow} = this.state; 
        return(
            <div id = 'firstpage'>
                <div className="pagetop">
                    <Mysearch onSearch={this.handleSearch.bind(this)} ></Mysearch>
                    <div className="resultCount">
                        <CountUp
                            start={0}
                            end = {this.state.DataToShow.length}
                        />
                    </div>
                    <div id="countlabel">ضابط صف</div>
                </div>
                <div className='cards-container'>
                    {
                        this.state.DataToShow.map((item) =>
                        <Card
                            cardname = {item.PERSON_NAME}
                            cardDegree = {item.DEGREE_NAME}
                            cardMilNo = {item.MIL_NO}
                            cardUnit = {item.UNIT_NAME}
                            cardDateDm = {item.DOF3A_TAGNEED_YEAR}
                        />
                        )
                    }
                </div>
                {/* <div id="cardsfooter" >created by Manzoma</div> */}
            </div>
        );        
    }

}

export default CardsList;