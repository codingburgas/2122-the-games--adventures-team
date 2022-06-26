import React from "react";
import Card from "./Components/Card";
import cardData from "./data/cardData";
import "./style/style.css";

function App() {
  return (
    <>
      {/* poster */}
      <div className="poster"></div>

      <div className="download--buttons">
        <button className="download__button__mobil download__button">
          PLAY ON PC
        </button>

        <button className="download__button__pc download__button">
          DOWNLOAD
        </button>
      </div>

      {/* Game info */}
      <div className="game--info--container">
        <p className="game__info">
          A ghosthunter dungeon crawler game, in which you and your cat
          companion go around killing ghosts.
        </p>
      </div>

      {/* Banner */}
      <div className="banner--container">
        <div className="baner"></div>
        <p className="banner__caption">Local ghost hunter duo</p>
      </div>

      {/* pictures */}
      <div className="image--container">
        <div className="image image1"></div>
        <div className="image image2"></div>
      </div>

      {/* developers */}
      <div className="developers--container">
        <h2 className="developer__title">DEVELOPERS</h2>
        <div className="developer__card--container">
          <div className="developer__card--container--column1">
            {cardData.map((item) => {
              return item.id < 3 && <Card item={item} key={item.id} />;
            })}
          </div>

          <div className="developer__card--container--column2">
            {cardData.map((item) => {
              return (
                item.id >= 3 &&
                item.id < 6 && <Card item={item} key={item.id} />
              );
            })}
          </div>

          <div className="developer__card--container--column3">
            {cardData.map((item) => {
              return (
                item.id > 5 &&
                item.id <= 7 && <Card item={item} key={item.id} />
              );
            })}
          </div>
        </div>
      </div>

      {/* Footer */}
      <footer className="footer">
        <a href="#" className="footer__github__link">
          Github
        </a>
        <div className="footer__unity"></div>
      </footer>
    </>
  );
}

export default App;
