import githubIcon from "../img/github.png";

export default function Card(props) {
  return (
    <>
      <div className="card--container">
        <a href={props.item.github} target="__blank">
          <img
            src={githubIcon}
            alt=""
            className="card__icon"
            width="35px"
            height="35px"
          />
        </a>

        <img src={props.item.img} alt="" className="card__image" />

        <h4 className="card__role">{props.item.role}</h4>
      </div>
    </>
  );
}
