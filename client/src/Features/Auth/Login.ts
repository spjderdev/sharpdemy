import { User } from "./Types";
import axios from "axios";
const API = "http://localhost:5284/api/Auth/login";
export const LoginService = async (user: User) => {
  const response = await axios.post(API, {
    email: user.email,
    password: user.password,
  });
  const { token } = response.data;
  return token;
};
