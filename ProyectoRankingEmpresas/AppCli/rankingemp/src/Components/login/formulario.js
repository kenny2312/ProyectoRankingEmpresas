import React, { Component } from 'react'
import AuthService from "../../services/auth.service";
import style from './App.module.css'
const Unicorn = () => (
  <span role='img' aria-label='unicornio'>
    🦄
  </span>
)

class InputControlado extends Component {
  state = {
    text: '',
    color: '#E8E8E8',
    type:'text'
  }

  actualizar = (event) => {
    const text = event.target.value
   const type=this.props.type;
    this.setState({ text ,type})

    // Propagando datos al padre
    this.props.onChange(this.props.name, text,this.props.type)
  }

  render () {
    const styles = {
      border: `1px solid ${this.state.color}`,
      padding: '0.3em 0.6em',
      outline: 'none',
      with:'600px'
    }
    return (
      <div >
      <input className={style['input']}
        type={this.state.type}
        value={this.state.text}
        onChange={this.actualizar}
        
        placeholder={this.props.placeholder}
      />
      </div>
    )
  }
}

class Form extends Component {
  state = {
    user: '',
    pass: '',
    message:''
  }

   componentDidMount  () {
      const user = JSON.parse(localStorage.getItem('user'));
      if (user && user.token) {
        this.props.history.push('/Users') 
      } 

  }

   handleLogin = async(e) => {
    e.preventDefault(); 
   //console.log(this.state);

    var loginIs=  await AuthService.login(this.state.user, this.state.pass);

    if(loginIs===true)   {
    this.props.history.push('/Users') 
    
    window.location.reload();}
    else{ alert("no login")  }
       
         
        
    
  };

  actualizar = (name, text) => {
    this.setState({
      [name]: text
    })
  }
  





  render () {
    return (
      
          <div className={style['contendor']}>
          <div className={style['contendor-flex']}>
        <h1>Login <Unicorn /></h1>
        <form onSubmit={this.handleLogin}>
        <InputControlado
          onChange={this.actualizar}
          placeholder='User'
          name='user'
          id='user'
          type='text'
        />
         
        <InputControlado
          onChange={this.actualizar}
          placeholder='Password'
          name='pass'
          id='pass'
          type='password'
        />
        <div>
       <input  type="submit" value="Aceptar" />
       </div>
        </form>
        </div>
        </div>
     
    )
  }
}
export default Form;