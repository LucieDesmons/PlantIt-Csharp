import React from 'react';
import "../style/Feed.css"
import "../style/Navbar.css"

const Feed = (e) => {
  //ouvre le profil
  const ClicProfil = (e) => {
    e.preventDefault();
    //ouvre lien !!!
  };

  return (
    <div>
      <h1>Feed</h1>
      <form onClick={ClicProfil}/>
    </div>
  );
};

export default Feed;