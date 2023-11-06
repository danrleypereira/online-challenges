import React, { useState, useContext, createContext } from 'react';
import { createRoot } from 'react-dom/client';

const languages = ['JavaScript', 'Python'];
const LanguageContext = createContext();

function App() {
  // implement Context here so can be used in child components
  const [language, setLanguage] = useState(languages[0])
  const toggleLanguage = () => {
    setLanguage((currentLanguage) => (currentLanguage === languages[0] ? languages[1] : languages[0]));
  };
  return (
    <LanguageContext.Provider value={{language, toggleLanguage}}>
      <MainSection />
    </LanguageContext.Provider>
  );
}

function MainSection() {
  const { language, toggleLanguage } = useContext(LanguageContext);
  return (
    <div>
      <p id="favoriteLanguage">favorite programing language: {language}</p>
      <button id="changeFavorite" onClick={toggleLanguage}>toggle language</button>
    </div>
  )
}

const container = document.getElementById('root');
const root = createRoot(container);
root.render(<App />);