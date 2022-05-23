function notify(message) {
  const notificationElement = document.querySelector('#notification');
  notificationElement.textContent = message;
  notificationElement.style.display = 'block';
  notificationElement.addEventListener('click', hideMessage);

  function hideMessage(e) {
    e.target.style.display = 'none';
  }
}