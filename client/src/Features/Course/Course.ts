import axios from "axios";
import { Course } from "./Types";

const API = "http://localhost:5284/api/Course";
export const GetAllCourse = async () => {
  let response = await axios.get<Course[]>(API);
  return response.data;
};
