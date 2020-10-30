import { artifacts } from '@/mock/artifacts-mock';


const getArtifacts = () => new Promise(resolve => resolve(artifacts));
const addArtifact = artifact => new Promise(resolve => resolve(artifact))
const updateArtifact = artifact => new Promise(resolve => resolve(artifact))
const deleteArtifact = id => new Promise(resolve => resolve(id))

export const artifactController = {
  getArtifacts,
  addArtifact,
  updateArtifact,
  deleteArtifact
};
