import { artifacts } from '@/mock/artifacts-mock';

const getArtifacts = () => new Promise(resolve => resolve(artifacts));

export const artifactController = {
  getArtifacts
};
