import React from "react";

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  label: string;
  className?: string;
  onClick: () => void;
}
// cool
const Button: React.FC<ButtonProps> = ({
  label,
  className,
  onClick,
  ...props
}) => {
  const { disabled } = props;
  const disabledClasses =
    "text-gray-500 bg-gray-200 border-gray-300 cursor-not-allowed rounded-md mr-2 p-2";
  const defaultClasses =
    "bg-[#09b5d1] text-white border-2 border-[#09b5d1] p-2 rounded-md hover:bg-[#020810] hover:text-[#febe11] transition duration-500 relative button-hover-line";

  return (
    <button
      {...props}
      onClick={onClick}
      className={
        !disabled ? `${defaultClasses} ${className || ""}` : disabledClasses
      }
    >
      {label}
    </button>
  );
};

export default Button;
