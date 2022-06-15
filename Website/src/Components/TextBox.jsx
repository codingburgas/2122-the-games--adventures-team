export default function TextBox(props) {
  return (
    <>
      <div className="textbox">
        <div className="textbox__decoration"></div>
        <div className="textbox__title__image__container">
          <img
            src={require("../img/test/num.png")}
            className="textbox__number"
          />
          <h2 className="textbox__title">{props.title}</h2>
        </div>
        <p className="textbox__content">{props.content}</p>
      </div>
    </>
  );
}
