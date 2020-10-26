const addResource = (apiMethod, mutation, constructor) => async (
  { commit },
  newResource
) => {
  await apiMethod(newResource).then(resource =>
    commit(mutation, new constructor(resource))
  );
};
const fetchResources = (apiMethod, mutation, constructor) => async ({
  commit
}) => {
  const resources = await apiMethod().then(resources =>
    resources.map(resource => new constructor(resource))
  );
  commit(mutation, resources);
};
const updateResource = addResource;

const deleteResource = (apiMethod, mutation) => async (
  { commit },
  resource
) => {
  await apiMethod(resource.id).then(commit(mutation, resource));
};

export const storeActions = {
  addResource,
  updateResource,
  deleteResource,
  fetchResources
};
