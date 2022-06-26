import githubIcon from "../img/github.png";

export default function Card(props) {
  return (
    <>
      <div className="card--container">
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
