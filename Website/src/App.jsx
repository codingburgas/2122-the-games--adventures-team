import React from "react";
import Card from "./Components/Card";
import cardData from "./data/cardData";
import "./style/style.css";
import penguin from "./img/penguin.png";
import { saveAs } from "file-saver";

function App() {
  const saveFile = () => {
    window.location.href =
      "https://github.com/codingburgas/2122-the-games--adventures-team/releases/download/1.0.0/Tarator.7z";
  };

  //get the download button
  const mobileButton = React.useRef(null);
  const pcButton = React.useRef(null);

  // getting card container class
  const cardContainer = React.useRef(null);

  // getting the cat
  const cat = React.useRef(null);

  React.useEffect(() => {
    // check the device is mobile
    if (
      /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
        navigator.userAgent
      )
    ) {
      // hiding the desktop button when it is on mobile
      pcButton.current.style.display = "none";

      // making the gap between team photo smaller when it is on phone
      cardContainer.current.style.gap = "9em";

      // making the cat smaller when it is on mobile
      cat.current.style.width = "100px";

      cat.current.style.bottom = "-75px";
      cat.current.style.right = "20px";
    } else {
      // hiding the mobile button when it is on desktop
      mobileButton.current.style.display = "none";
    }

    // get the elements
    const faders = document.querySelectorAll(".fade__in");
    const sliders = document.querySelectorAll(".slider__in");

    let options = {
      threshold: 0,
      rootMargin: "0px 0px -200px 0px",
    };

    const appearOnScroll = new IntersectionObserver(
      (entries, appearOnScroll) => {
        entries.forEach((entries) => {
          if (!entries.isIntersecting) {
            return;
          } else {
            entries.target.classList.add("appear");
            appearOnScroll.unobserve(entries.target);
          }
        });
      },
      options
    );

    faders.forEach((fader) => {
      appearOnScroll.observe(fader);
    });

    sliders.forEach((slider) => {
      appearOnScroll.observe(slider);
    });
  }, []);

  return (
    <>
      {/* poster */}
      <div className="poster"></div>

      <div className="download--buttons">
        <button
          className="download__button__mobile download__button"
          ref={mobileButton}
        >
          PLAY ON PC
        </button>

        <button
          className="download__button__pc download__button"
          ref={pcButton}
          onClick={saveFile}
        >
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
      <div className="banner--container fade__in">
        <div className="baner"></div>
        <p className="banner__caption">Local ghost hunter duo</p>
      </div>

      {/* pictures */}
      <div className="image--container">
        <div className="image image1 image__from__left slider__in"></div>
        <div className="image image2 image__from__right slider__in"></div>
      </div>

      {/* developers */}
      <div className="developers--container fade__in">
        <h2 className="developer__title">TEAM</h2>
        <div className="developer__card--container" ref={cardContainer}>
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
        <img src={penguin} alt="" className="penguin" ref={cat} />
      </div>

      {/* Footer */}
      <footer className="footer">
        <a
          href="https://github.com/codingburgas/2122-the-games--adventures-team"
          className="footer__github__link"
          target="__blank"
        >
          Github
        </a>

        <div className="footer__unity"></div>
      </footer>
    </>
  );
}

export default App;
