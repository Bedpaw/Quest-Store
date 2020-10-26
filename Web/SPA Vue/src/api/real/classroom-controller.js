import axios from "axios";

const url = "https://localhost:5001/api/classrooms"

const getClassrooms = async () => {
  try {
    const response = await axios.get(url);
    response.data.map( _class => {
      if(_class.students ==  null) _class.students = []
      if(_class.mentors == null) _class.mentors = []
    })
    console.log(response.data)
    return response.data
  } catch (error){
    console.log(error)
    return error
  }
}
const addClassroom = async ( _class ) => {
  try {
    const response = await axios.post(url, ({
      name: _class.name,
      description: _class.description,
      image: _class.image,
      students: _class.students,
      mentors: _class.mentors,
    }))
    console.log(response)
    return response.data


  } catch(error) {
    console.log(error)
  }
}

const updateClassroom = async ( _class ) => {
  try {
    const response = await axios.put(url +`/${_class.id}`, ({
      id : _class.id,
      name: _class.name,
      description: _class.description,
      image: _class.image,
      students: _class.students,
      mentors: _class.mentors,
    }))
    console.log(response)
    return response.data


  } catch(error) {
    console.log(error)
  }
}
const deleteClassroom = async (id) => {
  try {
    const response = await axios.delete(url + `/${id}`)
    return response.data
  } catch (error) {
    return error
  }
}


export const classroomController = {
  getClassrooms,
  addClassroom,
  updateClassroom,
  deleteClassroom
}
