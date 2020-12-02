import './App.css';
import {BrowserRouter,Route,useLocation,Switch} from 'react-router-dom'
import  Form from './Components/login/formulario.js';
import  User from './Components/User/User';
import  SignInSide from './Components/login/login.js';
import Dashboard from './Components/dashboard/Dashboard'
function App() {
  return (
    <div className="App">
       <BrowserRouter>
       <Switch>
       <Route  path='/login2' exact  component={Form} ></Route>
       <Route  path='/login' exact  component={SignInSide} ></Route>
                  <Route path='/User' exact component={User} ></Route>
        <Route path='/dash' exact component={Dashboard} ></Route>
        
       <Route exact path="*">
            <NoMatch />
          </Route>
          </Switch>
       </BrowserRouter>
       
    </div>
  );
}
function NoMatch() {
  let location = useLocation();

  return (
    <div>
      <h3>
        No match for <code>{location.pathname}</code>
      </h3>
      
    </div>
  );
}

export default App;
