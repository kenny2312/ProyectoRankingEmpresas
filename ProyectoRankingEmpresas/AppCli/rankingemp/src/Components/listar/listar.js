import React from 'react';
import './App.css'
import UserService from "../../services/user.service";
// para poder devolver varios intens usar fragment sino solo div

class Listar extends React.Component {
  
  state = {

    list: []
  }
  ListUser = async()=>{
    
    var list=  await UserService.getListUser()
    this.setState({list})
     
}  

  async componentDidMount  () {
    await this.ListUser();
    
  }
 
  render(){
    
    return(
   <div>
    <div>
        <h3>Lista de usuarios </h3>
        <div>
          {this.state.list.map((user) => (
              
              <li key={user.guid}>
                { user.name } - { user.lastName }
                </li>
             
            ))}
        </div>
      </div>
     
   </div>

    )
  }
  }
export default Listar;