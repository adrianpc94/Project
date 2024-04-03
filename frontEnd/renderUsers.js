
window.addEventListener("load", fetchUsers)

const BASE_URL = 'https://localhost:7282';

function fetchUsers() {
  setLoading(true);
  fetch(`${BASE_URL}/api/users`)
    .then(response => {
      if (!response.ok) {
        setLoading(false);
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(users => {
      setLoading(false);
      renderUsersList(users);
    })
    .catch(error => {
      console.error('There was a problem with the fetch operation:', error);
      setLoading(false);

    });
}

function renderUsersList(users) {
  const container = getCleanContainer("user-list");
  const userList = createUsersUnorderedList(users);
  container.appendChild(userList);
}

function getCleanContainer(containerId) {
  const container = document.getElementById(containerId);
  if (container === null) throw Error("Invalid container Id.");
  container.innerHTML = '';
  return container;
}

function createUsersUnorderedList(users) {
  const list = document.createElement("ul");

  users.forEach(user => {
    userListItem = createUserListItem(user);
    list.appendChild(userListItem)
  });
  return list;
}

function createUserListItem(user) {
  const listItem = document.createElement("li");
  const h4 = document.createElement("h4")
  h4.textContent = `${user.name} Id: ${user.id}`;
  listItem.appendChild(h4)
  return listItem;
}

function setLoading(loading) {
  const container = document.getElementById("spinner-container");
  container.style.display = loading ? "flex" : "none"
}