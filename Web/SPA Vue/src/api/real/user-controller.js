import axios from 'axios'

const url = 'https://localhost:5001/api/users'

const getUsers = async () => {
  try {
    const response = await axios.get(url);
    console.log(response)
    return response.data
  } catch (error){
    console.log(error)
    return error
  }
}

const addUser = async ( user ) => {
  try {
    const response = await axios.post(url, ({
      name: user.name,
      surname: user.surname,
      description: user.description,
      email: user.email,
      role: user.role,
      image: user.image,
      coins: user.coins,
      artifacts: user.artifacts
    }))
    console.log(response)
    return response.data


  } catch(error) {
    console.log(error)
  }
}



/*const getLoggedUser = async () => {
  try {
    const response = await axios.get(url + '/profile')
    return response.data
  } catch (error) {
    return error
  }
}*/

const updateUser = async (user) => {
  try {
    const response = await axios.put(url +`/${user.id}`, ({
      id: user.id,
      name: user.name,
      surname: user.surname,
      description: user.description,
      email: user.email,
      role: user.role,
      image: user.image,
      coins: user.coins,
      artifacts: user.artifacts
    }))
    console.log(response)
    return response.data
  } catch (error) {
    console.log(error)
    return error
  }
}
const getUser = async (id) => {
  try {
    const response = await axios.get(url + `/${id}`)
    return response.data
  } catch (error) {
    return error
  }
}
const deleteUser = async (id) => {
  try {
   const response = await axios.delete(url + `/${id}`)
    return response.data
  } catch (error) {
    return error
  }
}

export const userController = {
  getUsers,
  //getLoggedUser,
  addUser,
  updateUser,
  getUser,
  deleteUser
}
