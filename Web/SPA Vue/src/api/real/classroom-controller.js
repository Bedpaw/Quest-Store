import axios from "axios";

const url = "https://localhost:5001/api/classrooms"

const getClassrooms = async () => {
  try {
    const response = await axios.get(url);
    console.log(response.data)
    return response.data
  } catch (error){
    console.log(error)
    return error
  }
}

export const classroomController = {
  getClassrooms
}
