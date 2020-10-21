import axios from "axios";

const url = "https://localhost:5001/api/artifacts"

const getArtifacts = async () => {
  try {
    const response = await axios.get(url);
    console.log(response.data)
    response.data
  } catch (error){
    console.log(error)
    return error
  }
}

export const artifactController = {
  getArtifacts
}
