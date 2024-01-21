import "../styles/globals.css"; // This imports Tailwind CSS
import type { AppProps } from "next/app";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <div className="bg-white min-h-screen m-0 text-[#000810]">
      <Component {...pageProps} />
    </div>
  );
}

export default MyApp;
