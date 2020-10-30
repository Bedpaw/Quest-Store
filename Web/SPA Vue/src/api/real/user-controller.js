import axios from 'axios';

const url = 'https://localhost:5001/api';
const usersUrl = url + '/users';
const studentsUrl = url + '/students'

// generic get
const getByRole = (urlForRole) => async () => {
  try {
    const response = await axios.get(urlForRole);
    console.log(response);
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
};

const getUsers = getByRole(usersUrl)
const getStudents = getByRole(studentsUrl)



const addUser = async user => {
  try {
    const response = await axios.post(usersUrl, {
      name: user.name,
      surname: user.surname,
      description: user.description,
      email: user.email,
      role: user.role,
      image: user.image,
      coins: user.coins,
      artifacts: user.artifacts
    });
    console.log(response);
    return response.data;
  } catch (error) {
    console.log(error);
  }
};

/*const getLoggedUser = async () => {
  try {
    const response = await axios.get(url + '/profile')
    return response.data
  } catch (error) {
    return error
  }
}*/

const updateUser = async user => {
  try {
    const response = await axios.put(usersUrl + `/${user.id}`, {
      id: user.id,
      name: user.name,
      surname: user.surname,
      description: user.description,
      email: user.email,
      role: user.role,
      image: user.image,
      coins: user.coins,
      artifacts: user.artifacts
    });
    console.log(response);
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
};
const getUser = async id => {
  try {
    const response = await axios.get(usersUrl + `/${id}`);
    return response.data;
  } catch (error) {
    return error;
  }
};
const deleteUser = async id => {
  try {
    const response = await axios.delete(usersUrl + `/${id}`);
    return response.data;
  } catch (error) {
    return error;
  }
};

// api/students/{studentId}/artifacts
const updateStudentArtifacts = async user => {
  try {
    const response = await axios.put(studentsUrl + `/${user.id}` + '/artifacts', {
      artifacts: user.artifacts
    });
    console.log(response);
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
};


export const userController = {
  getUsers,
  //getLoggedUser,
  addUser,
  updateUser,
  getUser,
  deleteUser,
  getStudents,
  updateStudentArtifacts
};
