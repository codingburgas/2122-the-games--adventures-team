import githubIcon from "../img/github.png";
import React from "react";

export default function Card(props) {
  const card = React.useRef(null);

  React.useEffect(() => {
    if (
      /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
        navigator.userAgent
      )
    ) {
      card.current.style.width = "120px";
      card.current.style.height = "150px";
    }
  }, []);

  return (
    <>
      <div className="card--container" ref={card}>
        <div className="card__darken"></div>
        <img src={props.item.img} alt="" className="card__image" />
        <div className="card__info">
          <a href={props.item.github} target="__blank">
            <img
              src={githubIcon}
              alt=""
              className="card__icon"
              width="35px"
              height="35px"
            />
          </a>

          <h4 className="card__role">{props.item.role}</h4>
        </div>
      </div>
    </>
  );
}
