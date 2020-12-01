import axios from "axios";

const API_URL = "http://localhost:44392/api/Login/";

const register = (username, email, password) => {
  return axios.post(API_URL + "signup", {
    username,
    email,
    password,
  });
};

const  login = async (user, pass) => {
 
   var data = JSON.stringify({"username":user,"password":pass});
    var log=false;
   var config = {
     method: 'post',
     url: 'https://localhost:44392/api/Login/authenticate',
     headers: { 
       'Content-Type': 'application/json'
     },
     data : data
   };
  await  axios(config)
   .then(function (response) {
    //console.log(JSON.stringify(response.data));
    if (response.data.token) {
      localStorage.setItem("user", JSON.stringify(response.data));
    }
    log= true;
   })
   .catch(function (error) {
     //console.log(error.message);
     log= false;
   });
   return log;

};

const logout = () => {
  localStorage.removeItem("user");
};

const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem("user"));
};



export default {
  register,
  login,
  logout,
  getCurrentUser,
};