import React, { useState } from 'react';
import "../style/Messagerie.css"
import "../style/Navbar.css"

const MessengerPage = () => {
  const [messages, setMessages] = useState([]);
  const [inputValue, setInputValue] = useState('');

  const handleInputChange = (event) => {
    setInputValue(event.target.value);
  };

  //nouveau message
  const handleSendMessage = () => {
    if (inputValue !== '') {
      const newMessage = {
        id: messages.length + 1,
        text: inputValue,
        timestamp: new Date().getTime()
        //envoyer aussi idConv et idEnvoyeur
      };

      setMessages([...messages, newMessage]);
      setInputValue('');
    }
  };

  return (
    <div>
      <h1>Messages</h1>
      <div className="message-container">
        {messages.map((message) => (
          <div key={message.id} className="message">
            <p>{message.text}</p>
            <span>{new Date(message.timestamp).toLocaleString()}</span>
          </div>
        ))}
      </div>
      <div className="input-container">
        <input
          type="text"
          value={inputValue}
          onChange={handleInputChange}
          placeholder="Votre message..."
        />
        <button onClick={handleSendMessage}>Send</button>
      </div>
    </div>
  );
};

export default MessengerPage;