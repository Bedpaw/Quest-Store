/*import axios from 'axios'

const url = 'https://localhost:5001/QuestStore/api/users'


const getUsers = async () => {
  try {
    const response = await axios.get(url);
    console.log(response)
    return response
  } catch (error){
    console.log(error)
    return error
  }
}
/!*
const addUser = async ({ user }) => {
  try {
    const response = await axios.post(url, {
      name, surname, description,
      email, role, image,
      coins, artifacts
    })
    console.log(response)
    return response


  } catch(error) {

  }
}
const updateUser = async (...user) => {
  try {
    const response = await axios.put(url, {
      id, name, surname, description, email, role, image, coins, artifacts
    })
    console.log(response)
    return response
  } catch (error) {
    console.log(error)
    return error
  }
}*!/

const getUser = async (id) => {
  try {
    const response = await axios.get(url + '/id')
    return response
  } catch (error) {
    return error
  }
}
const deleteUser = async (id) => {
  try {
   const response = await axios.delete(url + '/id')
    return response
  } catch (error) {
    return error
  }
}

export const userController = {
  getUsers,
  addUser,
  updateUser,
  getUser,
  deleteUser
}*/
