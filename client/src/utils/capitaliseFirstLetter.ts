export const capitalizeFirstLetter = (inputString: string) => {
  if (!inputString) return "";
  return inputString.charAt(0).toUpperCase() + inputString.slice(1);
};
