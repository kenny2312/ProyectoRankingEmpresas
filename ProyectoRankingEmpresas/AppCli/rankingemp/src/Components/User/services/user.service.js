import axios from "axios";
import authHeader from "../../../services/auth-Header";

const API_URL = "https://localhost:44392/api/User/";

const getListUser = async () => {
 
let list=[];
var config = {
  method: 'get',
  url: API_URL + "List",
  headers:  authHeader()
   
  
};
 await axios(config).then((response)=>{

    list =response.data;

  }).catch((error)=>console.log(error));
  return list;
};

const getUserBoard = () => {
  return axios.get(API_URL + "user", { headers: authHeader() });
};

const getModeratorBoard = () => {
  return axios.get(API_URL + "mod", { headers: authHeader() });
};

const getAdminBoard = () => {
  return axios.get(API_URL + "admin", { headers: authHeader() });
};

export default {
  getListUser,
  getUserBoard,
  getModeratorBoard,
  getAdminBoard,
};