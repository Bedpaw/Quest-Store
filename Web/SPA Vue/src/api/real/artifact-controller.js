import axios from "axios";

const url = "https://localhost:5001/api/artifacts"

const getArtifacts = async () => {
  try {
    const response = await axios.get(url);
    console.log(response.data)
    return response.data
  } catch (error){
    console.log(error)
    return error
  }
}

const addArtifact = async (artifact) => {
  try {
    const response = await axios.post(url, ({
      name: artifact.name,
      description: artifact.description,
      image: artifact.image,
      cost: artifact.cost,
      quantity: artifact.quantity
    }))
    console.log(response)
    return response.data


  } catch (error) {
    console.log(error)
  }
}
const updateArtifact = async (artifact) => {
  try {
    const response = await axios.put(url + `/${artifact.id}`, ({
      name: artifact.name,
      description: artifact.description,
      image: artifact.image,
      cost: artifact.cost,
      quantity: artifact.quantity
    }))
    console.log(response)
    return response.data


  } catch (error) {
    console.log(error)
  }
}
const deleteArtifact = async (id) => {
  try {
    const response = await axios.delete(url + `/${id}`)
    return response.data
  } catch (error) {
    return error
  }
}

export const artifactController = {
  getArtifacts,
  addArtifact,
  updateArtifact,
  deleteArtifact
}
